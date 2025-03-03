import { Box } from "@mui/material";
import ActivityCard from "./ActivityCard";

type ActivityListProps = {
    activities: Activity[],
    selectActivity: (id: string) => void,
    deleteActivity: (id: string) => void
}

export default function ActivityList(props: ActivityListProps) {
  const {activities, selectActivity, deleteActivity} = props;
  return (
    <Box sx={{display: "flex", flexDirection: "column", gap: 3}}>
        {activities.map(actv => (
            <ActivityCard 
              key={actv.id} 
              activity={actv} 
              selectActivity={selectActivity} 
              deleteActivity={deleteActivity}
            />
        ))}
    </Box>
  )
}
