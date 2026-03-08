import React, { useState } from "react";
import {
    TextField,
    Button,
    DialogTitle,
    DialogContent,
    DialogActions
} from "@mui/material";
import { createCitizen } from "../api/citizenApi"
import "../style/AddCitizen.css";

function AddCitizen() {

    const [fullName, setFullName] = useState("");
    const [identityCitizen, setIdentityCitizen] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newCitizen = {
            CitizenId: 0,
            IdentityCitizen: identityCitizen,
            FullName: fullName
        };

        try {
            await createCitizen(newCitizen);
            alert("האזרח נשמר בהצלחה");
        } catch (error) {
            console.error(error);
        }
    };

    return (
<div className="add-citizen-container">
            <DialogTitle className="add-citizen-title">הוספת אזרח חדש</DialogTitle>

            <DialogContent sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}>
                <TextField
                    label="תעודת זהות"
                    fullWidth
                    margin="normal"
                    value={identityCitizen}
                    onChange={(e) => setIdentityCitizen(e.target.value)}
                    className="add-citizen-textfield"
                />

                <TextField
                    label="שם מלא"
                    fullWidth
                    margin="normal"
                    value={fullName}
                    onChange={(e) => setFullName(e.target.value)}
                    className="add-citizen-textfield"
                />
            </DialogContent>

            <DialogActions>
                <Button
                    variant="contained"
                    onClick={handleSubmit}
                    className="add-citizen-button"
                >
                    שמור
                </Button>
            </DialogActions>
        </div>
    );
}

export default AddCitizen;