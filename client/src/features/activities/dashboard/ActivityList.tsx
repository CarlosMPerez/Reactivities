import { Box } from "@mui/material";
import ActivityCard from "./ActivityCard";

type ActivityListProps = {
    activities: Activity[],
    selectActivity: (id: string) => void 
}

export default function ActivityList({activities, selectActivity}: ActivityListProps) {
  return (
    <Box sx={{display: "flex", flexDirection: "column", gap: 3}}>
        {activities.map(actv => (
            <ActivityCard key={actv.id} activity={actv} selectActivity={selectActivity} />
        ))}
    </Box>
  )
}
