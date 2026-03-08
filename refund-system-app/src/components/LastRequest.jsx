import { useEffect, useState } from "react";
import { getLastRefundRequestByCitizenId } from "../api/refundApi"

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
        <div style={{
            border: "1px solid #ccc",
            borderRadius: "10px",
            padding: "20px",
            marginTop: "20px",
            width: "400px"
        }}>
            <h2>הבקשה האחרונה שלך</h2>

            {lastRequest ? (
                <div>
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