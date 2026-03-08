import { useEffect, useState } from "react";
import { getLastRefundRequestByCitizenId } from "../api/refundApi"
import "../style/LastRequest.css";


function LastRequest({ id }) {

    const [lastRequest, setLastRequest] = useState(null);

    useEffect(() => {
        const fetchLastRequest = async () => {
            try {
                const data = await getLastRefundRequestByCitizenId(id);
                setLastRequest(data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchLastRequest();
    }, [id]);

    return (
        <div className="last-request-container">

            <h2 className="last-request-title">הבקשה האחרונה שלך</h2>

            {lastRequest ? (
                <div className="last-request-info">
                    <p><b>מספר בקשה:</b> {lastRequest.requestId}</p>
                    <p><b>גובה הזכאות:</b> {lastRequest.refundAmount} ₪</p>
                    <p><b>סטטוס:</b> {lastRequest.status}</p>
                </div>

            ) : (
                <p>לא נמצאה בקשה</p>
            )}
        </div>
    )
}

export default LastRequest