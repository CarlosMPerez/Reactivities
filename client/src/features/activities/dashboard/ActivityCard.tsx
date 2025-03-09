import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Chip,
  Typography,
} from "@mui/material";
import { useActivities } from "../../../lib/hooks/useActivities";

type ActivityCardProps = {
  activity: Activity;
};

export default function ActivityCard(props: ActivityCardProps) {
  const { activity } = props;
  const { deleteActivity } = useActivities();

  return (
    <Card sx={{ borderRadius: 3 }}>
      <CardContent>
        <Typography variant="h5">{activity.title}</Typography>
        <Typography sx={{ color: "text.secondary", marginButton: 1 }}>
          {activity.date.split("T")[0]}
        </Typography>
        <Typography variant="body2">{activity.description}</Typography>
        <Typography variant="subtitle1">
          {activity.city} / {activity.venue}
        </Typography>
      </CardContent>
      <CardActions
        sx={{
          display: "flex",
          justifyContent: "space-between",
          paddingBottom: 2,
        }}
      >
        <Chip label={activity.category} variant="outlined" />
        <Box display="flex" gap={2}>
          <Button
            onClick={() => deleteActivity.mutate(activity.id)}
            disabled={deleteActivity.isPending}
            color="error"
            size="medium"
            variant="contained"
          >
            Delete
          </Button>
          <Button
            onClick={() => {}}
            size="medium"
            variant="contained"
          >
            View
          </Button>
        </Box>
      </CardActions>
    </Card>
  );
}
