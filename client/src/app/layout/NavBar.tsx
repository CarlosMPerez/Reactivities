import { Group } from '@mui/icons-material';
import { Box, AppBar, Toolbar, 
    Container, MenuItem, 
    Typography,
    Button} from '@mui/material';

type NavBarProps = {
    openForm: () => void;
}

export default function NavBar(props: NavBarProps) {
    const {openForm} = props;

  return (
    <Box sx={{ flexGrow: 1 }}>
    <AppBar position="static" sx={{ 
        backgroundImage: 'linear-gradient(1354deg, #182a73 0%, #218aae 69%, #20a7ac 89%)'
    }}>
        <Container maxWidth='xl'>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between'}}>
                <Box>
                    <MenuItem sx={{display: 'flex', gap: 2}}>
                        <Group fontSize="large" />
                        <Typography variant="h4" fontWeight="bold">Reactivities</Typography>
                    </MenuItem>
                </Box>
                <Box sx={{display: "flex"}}>
                    <MenuItem 
                        sx={{fontSize3: "1.2rem", 
                        textTransfom: "uppercase", 
                        fontWeight: "bold"
                    }}>
                        Activities
                    </MenuItem>
                    <MenuItem 
                        sx={{fontSize3: "1.2rem", 
                        textTransfom: "uppercase", 
                        fontWeight: "bold"
                    }}>
                        About
                    </MenuItem>
                    <MenuItem 
                        sx={{fontSize3: "1.2rem", 
                        textTransfom: "uppercase", 
                        fontWeight: "bold"
                    }}>
                        Contact
                    </MenuItem>
                </Box>
                <Button 
                    size="large" 
                    variant="contained" 
                    color="warning"
                    onClick={openForm}
                    >
                        Create activity
                </Button>
            </Toolbar>
        </Container>
    </AppBar>
  </Box>
  )
}
