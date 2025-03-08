import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import agent from "../api/agent";

export const useActivities = () => {
  const queryClient = useQueryClient();

  // useQuery runs AUTO when the component mounts or when its queryKey changes
  const { data: activities, isPending } = useQuery({
    queryKey: ["activities"], // unique key for caching the query, NOT the API result
    queryFn: async () => {
      // Fetch data from the API using Axios (configured in the agent.ts)
      const response = await agent.get<Activity[]>("/activities");
      return response.data;
    },
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
      await agent.post("/activities", activity);
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
  };
};
