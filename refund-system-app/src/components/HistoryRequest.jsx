import { useEffect, useState } from "react";
import { getRefundRequestByCitizenId } from "../api/refundApi"
import "../style/HistoryRequest.css";


function HistoryRequest({ id }) {

    const [requestsHistory, setRequestsHistory] = useState([]);

    useEffect(() => {
        const fetchHistory = async () => {
            try {
                const data = await getRefundRequestByCitizenId(id);
                setRequestsHistory(data);
                console.log(data)
            } catch (error) {
                console.error(error);
            }
        };

        fetchHistory();
    }, [id]);

    return (
       <div className="history-container">
            <h2 className="history-title">היסטוריית בקשות</h2>

            <table className="history-table">
                <thead>
                    <tr>
                        <th>מספר בקשה</th>
                        <th>גובה זיכוי</th>
                        <th>סטטוס</th>
                    </tr>
                </thead>

                <tbody>
                    {requestsHistory.map((req) => (
                        <tr key={req.requestId}>
                            <td>{req.requestId}</td>
                            <td>₪ {req.refundAmount}</td>
                            <td>{req.status}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default HistoryRequest