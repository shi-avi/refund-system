import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getPendingRefundRequests } from "../api/refundApi"
import "../style/AllRefundsPage.css";

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

 function formatDate(dateString) {
  if (!dateString) return "";
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
}

  return (
    <div className="page-container">

      <h2 className="page-title">בקשות ממתינות</h2>

      <div className="requests-list">
        {requests.map((req) => (
          <div
            key={req.requestId}
            className="request-card"
            onClick={() => navigate(`/citizenDetails/${req.citizenId}/${req.requestId}`)}
          >
            <div className="request-info">
              <p>מספר בקשה: {req.requestId}</p>
              <p>מזהה אזרח: {req.citizenId}</p>
              <p>תאריך בקשה: {formatDate(req.createdAt) }</p>
            </div>
          </div>
        ))}
      </div>

    </div>
  );
}

export default AllRefundsPage