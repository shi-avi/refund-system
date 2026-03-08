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
import "../style/HomePage.css";

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
        <div className="page-container" >
        <div className="card">
            <h1 className="title">מערכת חישוב זכאות</h1>
            <Box className="form-box">
                <TextField
                        label="הכנס תעודת זהות"
                        type="text"
                        value={identityCitizen}
                        onChange={(e) => setIdentityCitizen(e.target.value)}
                        fullWidth
                    />

                    <Button
                        variant="contained"
                        className="main-button"
                        onClick={handleSubmit}
                    >
                        שלח
                    </Button>

                    <Button
                        variant="contained"
                        className="secondary-button"
                        onClick={() => navigate("/allRefunds")}
                    >
                        כניסה כפקיד
                    </Button>

                    <Button
                        variant="outlined"
                        className="outline-button"
                        onClick={() => setAddCitizen(true)}
                    >
                        הוספת אזרח חדש
                    </Button>
            </Box>
            <Dialog open={addCitizen} onClose={() => setAddCitizen(false)}>
                <AddCitizen />
            </Dialog>
        </div>
        </div>
    )
}

export default HomePage