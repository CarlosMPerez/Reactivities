import { Typography, Box, Container, CssBaseline } from "@mui/material";
import { useState } from "react";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import { useActivities } from "../../lib/hooks/useActivities";

function App() {
  const [selectedActivity, setSelectedActivity] = 
    useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  const {activities, isPending} = useActivities();

  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities!.find(x => x.id === id));
  };

  const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  };

  const handleFormOpen = (id?: string) => {
    if (id) handleSelectActivity(id);
    else handleCancelSelectActivity();
    setEditMode(true);
  }

  const handleFormClose = () => {
    setEditMode(false);
  }

  const handleSubmitForm = (activity: Activity) => {
    // if (activity.id) {
    //   setActivities(activities!.map(x => x.id === activity.id ? 
    //     activity : x
    //   ))
    // } else {
    //   const newActivity = {...activity, id: activities.length.toString()}
    //   setSelectedActivity(newActivity);
    //   setActivities([...activities, newActivity])
    // }

    console.log(activity);
    setEditMode(false);
  }

  const handleDelete = (id: string) => {
    //setActivities(activities.filter(x => x.id !== id));
    console.log(id);
  }

  return (
    <Box sx={{bgcolor: "#eeeeee", minHeight: "100vh"}}>
      <CssBaseline />
      <NavBar 
        openForm={handleFormOpen}
      />
      <Container maxWidth="xl" sx={{marginTop: 3}}>
        {!activities || isPending ? (
          <Typography>Loading...</Typography>
        ) : (
            <ActivityDashboard 
              activities={activities}
              selectedActivity={selectedActivity}
              selectActivity={handleSelectActivity}
              cancelSelectActivity={handleCancelSelectActivity}
              editMode={editMode}
              openForm={handleFormOpen}
              closeForm={handleFormClose}
              submitForm={handleSubmitForm}
              deleteActivity={handleDelete}
            />
        )}
      </Container>
    </Box>
  );
}

export default App;
