import { Box, Button, Card, CardActions, 
    CardContent, Chip, Typography } from "@mui/material"

type ActivityCardProps = {
    activity: Activity,
    selectActivity: (id: string) => void,
    deleteActivity: (id: string) => void
}

export default function ActivityCard(props: ActivityCardProps) {
    const {activity, selectActivity, deleteActivity} = props;
    return (
        <Card sx={{borderRadius: 3}}>
            <CardContent>
                <Typography variant="h5">{activity.title}</Typography>
                <Typography sx={{color: "text.secondary", marginButton: 1}}>{activity.date}</Typography>
                <Typography variant="body2">{activity.description}</Typography>
                <Typography variant="subtitle1">{activity.city} / {activity.venue}</Typography>
            </CardContent>
            <CardActions 
                sx={{display: "flex", 
                justifyContent: "space-between", 
                paddingBottom: 2}}
            >
                <Chip label={activity.category} variant="outlined" />
                <Box display="flex" gap={2}>
                    <Button onClick={() => deleteActivity(activity.id)} 
                        color="error" size="medium" variant="contained">Delete</Button>
                    <Button onClick={() => selectActivity(activity.id)} 
                        size="medium" variant="contained">View</Button>
                </Box>
            </CardActions>
        </Card>
    );
}
