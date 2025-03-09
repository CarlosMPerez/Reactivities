import { Box, Typography } from "@mui/material";
import ActivityCard from "./ActivityCard";
import { useActivities } from "../../../lib/hooks/useActivities";

export default function ActivityList() {
  
  // Loading of activities using react.query hooks (and axios)
  const { activities, isPending } = useActivities();

  if (!activities || isPending) return <Typography>Loading...</Typography>
  
  return (
    <Box sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
      {activities.map((actv) => (
        <ActivityCard
          key={actv.id}
          activity={actv}
        />
      ))}
    </Box>
  );
}
