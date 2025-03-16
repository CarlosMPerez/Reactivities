import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import agent from "../api/agent";
import { useLocation } from "react-router";

export const useActivities = (id?: string) => {
  const queryClient = useQueryClient();
  const location = useLocation();

  // useQuery runs AUTO when the component mounts or when its queryKey changes
  const { data: activities, isPending } = useQuery({
    queryKey: ["activities"], // unique key for caching the query, NOT the API result
    queryFn: async () => {
      // Fetch data from the API using Axios (configured in the agent.ts)
      const response = await agent.get<Activity[]>("/activities");
      return response.data;
    },
    // only performs the query if not id and in the path activities, so the
    // query is not performed when loading the create activity form, for example.
    enabled: !id && location.pathname === "/activities",
  });

  // this userQuery would ALSO run automatically every time a component that uses
  // the hook useActivities is loaded, even if it has an id or not. So we
  // include the field enabled to determine if its needed or not
  const { data: activity, isLoading: isLoadingActivity } = useQuery({
    queryKey: ["activities", id],
    queryFn: async () => {
      const response = await agent.get<Activity>(`/activities/${id}`);
      return response.data;
    },
    enabled: !!id,
  });

  // useMutation is the method used to update data via a PUT request also using axios
  const updateActivity = useMutation({
    mutationFn: async (activity: Activity) => {
      await agent.put("/activities", activity);
    },
    onSuccess: async () => {
      // invalidateQueries marks the cached data (identified by ['activities']) as stale
      // triggering an automatic re-fetch from the API
      await queryClient.invalidateQueries({
        queryKey: ["activities"],
      });
    },
  });

  // same as before, but in this case we use a POST API call
  const createActivity = useMutation({
    mutationFn: async (activity: Activity) => {
      const response = await agent.post("/activities", activity);
      return response.data;
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({
        queryKey: ["activities"],
      });
    },
  });

  const deleteActivity = useMutation({
    mutationFn: async (id: string) => {
      await agent.delete(`/activities/${id}`);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({
        queryKey: ["activities"],
      });
    },
  });

  return {
    activities,
    isPending,
    updateActivity,
    createActivity,
    deleteActivity,
    activity,
    isLoadingActivity,
  };
};
