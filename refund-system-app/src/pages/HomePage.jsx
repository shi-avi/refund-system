import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
import {
    TextField,
    Button,
    Box,
    Dialog
} from "@mui/material";
import { getCitizenByIdentity } from "../api/citizenApi"
import AddCitizen from "../components/AddCitizen";

function HomePage() {
    const [identityCitizen, setIdentityCitizen] = useState("");
    const [addCitizen, setAddCitizen] = useState(false)

    const navigate = useNavigate();

    const handleSubmit = async () => {
        try {
            const citizen = await getCitizenByIdentity(identityCitizen);
            navigate(`/citizen/${citizen.citizenId}`);
        } catch (error) {
            console.error("שגיאה בשליפת אזרח:", error.response?.data || error.message);
        }
    };

    return (
        <div>
            <h1>כאן מחשבים זכאות :)</h1>
            <Box sx={{ display: "flex", flexDirection: "column", gap: 2, width: 300 }}>
                <TextField
                    id="outlined-citizen-id"
                    label="הכנס תעודת זהות"
                    type="text"
                    value={identityCitizen}
                    onChange={(e) => setIdentityCitizen(e.target.value)}
                />
                <Button variant="contained" onClick={handleSubmit}>
                    שלח
                </Button>
                <Button variant="contained" onClick={() => navigate("/allRefunds")}>
                    הכנס כפקיד
                </Button>
                <Button variant="outlined" onClick={() => setAddCitizen(true)}>
                    הוספת אזרח חדש
                </Button>
            </Box>
            <Dialog open={addCitizen} onClose={() => setAddCitizen(false)}>
                <AddCitizen />
            </Dialog>
        </div>
    )
}

export default HomePage