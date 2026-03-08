import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getPendingRefundRequests } from "../api/refundApi"

function AllRefundsPage() {

  const [requests, setRequests] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchRequests = async () => {
      const res = await getPendingRefundRequests();
      setRequests(res);
    };

    fetchRequests();
  }, []);

  return (
    <div>
      <h2>בקשות ממתינות</h2>
      {requests.map((req) => (
        <div
          key={req.requestId}
          style={{
            border: "1px solid gray",
            padding: "10px",
            marginBottom: "10px",
            cursor: "pointer"
          }}
          onClick={() => navigate(`/citizenDetails/${req.citizenId}/${req.requestId}`)}
        >
          <p>מספר בקשה: {req.requestId}</p>
          <p>מזהה אזרח: {req.citizenId}</p>
          <p>תאריך בקשה: {req.createdAt}</p>
        </div>
      ))}

    </div>
  )
}

export default AllRefundsPage