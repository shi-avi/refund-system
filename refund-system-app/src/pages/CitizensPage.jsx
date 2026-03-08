import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Dialog } from "@mui/material";
import { getCitizenById } from "../api/citizenApi";
import AddRefundRequest from "../components/AddRefundRequest";
import LastRequest from "../components/LastRequest";
import HistoryRequest from "../components/HistoryRequest";

function CitizensPage() {
    const [citizen, setCitizen] = useState(null);
    const [addRefundRequest, setAddRefundRequest] = useState(false)

    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const fetchCitizen = async () => {
            try {
                const data = await getCitizenById(id);
                setCitizen(data);
            }
            catch (error) {
                alert("לא קיים אזרח כזה");
                navigate("/")
            }
        };
        fetchCitizen();
    }, [id]);

    if (!citizen) return <div>טוען...</div>;

    return (

        <div style={{ padding: "30px" }}>

            <h1>ברוך הבא {citizen.fullName}</h1>

            <Button variant="outlined" onClick={() => setAddRefundRequest(true)}>
                הוספת בקשת החזר חדשה
            </Button>

            <LastRequest id={id} />

            <HistoryRequest id={id} />

            <Dialog open={addRefundRequest} onClose={() => setAddRefundRequest(false)}>
                <AddRefundRequest id={id} />
            </Dialog>

        </div>
    )
}

export default CitizensPage