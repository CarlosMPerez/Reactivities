import { Grid2 } from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityDetail from "../details/ActivityDetail";
import ActivityForm from "../form/ActivityForm";

type ActivityDashBoardProps = {
    activities: Activity[],
    selectedActivity: Activity | undefined,
    selectActivity: (id: string) => void,
    cancelSelectActivity: () => void,
    editMode: boolean,
    openForm: () => void,
    closeForm: () => void,
    submitForm: (activity: Activity) => void,
    deleteActivity: (id: string) => void
};

export default function ActivityDashboard(props: ActivityDashBoardProps) {
    const {activities, selectedActivity, 
        selectActivity, cancelSelectActivity, 
        editMode, openForm, closeForm, submitForm, deleteActivity} = props;
    return (
        <Grid2 container spacing={3}>
            <Grid2 size={7}>
                <ActivityList 
                    activities={activities} 
                    selectActivity={selectActivity}
                    deleteActivity={deleteActivity}
                />
            </Grid2>
            <Grid2 size={5}>
                {selectedActivity && !editMode &&
                    <ActivityDetail 
                        activity={selectedActivity} 
                        cancelSelectActivity={cancelSelectActivity}
                        openForm={openForm}
                    />
                }
                {editMode && 
                    <ActivityForm 
                        closeForm={closeForm} 
                        activity={selectedActivity}
                        submitForm={submitForm} 
                    />
                }
            </Grid2>
        </Grid2>
    )
}
