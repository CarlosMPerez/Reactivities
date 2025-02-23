import { Grid2 } from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityDetail from "../details/ActivityDetail";

type ActivityDashBoardProps = {
    activities: Activity[],
    selectedActivity: Activity | undefined,
    selectActivity: (id: string) => void,
    cancelSelectActivity: () => void
};

export default function ActivityDashboard(props: ActivityDashBoardProps) {
    const {activities, selectedActivity, selectActivity, cancelSelectActivity} = props;
    return (
        <Grid2 container spacing={3}>
            <Grid2 size={7}>
                <ActivityList 
                    activities={activities} 
                    selectActivity={selectActivity}
                />
            </Grid2>
            <Grid2 size={5}>
                {selectedActivity && 
                <ActivityDetail 
                    activity={selectedActivity} 
                    cancelSelectActivity={cancelSelectActivity}
                />}
            </Grid2>
        </Grid2>
    )
}
