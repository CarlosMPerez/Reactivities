import { MenuItem } from "@mui/material";
import { ReactNode } from "react";
import { NavLink } from "react-router";

type MenuItemLinkProps = {
    children: ReactNode,
    to: string
};


export default function MenuItemLink(props: MenuItemLinkProps) {
    const { children, to} = props;
    return (
        <MenuItem 
            component={NavLink} 
            to={to} 
            sx={{
                fontSize: "1.2rem",
                textTransform: "upperCase",
                fontWeight: "bold",
                color: "inherit",
                "&.active": {
                    color: "yellow"
                }
        }}>
            {children}
        </MenuItem>

    );
}
