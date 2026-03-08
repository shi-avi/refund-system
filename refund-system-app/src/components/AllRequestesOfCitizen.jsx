import { useEffect, useState } from "react";
import {
    Typography,
    CardContent,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Chip,
    Divider,
} from "@mui/material";
import { getRefundRequestByCitizenId } from '../api/refundApi'
import "../style/AllRequestesOfCitizen.css";



function AllRequestesOfCitizen({ citizenId }) {

    const [citizenRequests, setCitizenRequests] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            if (!citizenId) return;
            try {
                const requestsRes = await getRefundRequestByCitizenId(citizenId);
                setCitizenRequests(requestsRes);
            } catch (error) {
                console.log(error);
            }
        };
        fetchData();
    }, [citizenId]);

    return (
       <CardContent className="all-requests-container">
      <Typography variant="h6" className="all-requests-title" gutterBottom>
        כל הבקשות של האזרח
      </Typography>

      <Divider sx={{ mb: 2 }} />

      <TableContainer component={Paper}>
        <Table className="all-requests-table">
          <TableHead>
            <TableRow>
              <TableCell>מספר בקשה</TableCell>
              <TableCell>סכום</TableCell>
              <TableCell>סטטוס</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {citizenRequests.map((req) => (
              <TableRow key={req.requestId}>
                <TableCell>{req.requestId}</TableCell>
                <TableCell>₪ {req.refundAmount}</TableCell>
                <TableCell>
                  <Chip
                    label={req.status}
                    className="status-chip"
                    color={
                      req.status === "Approved"
                        ? "success"
                        : req.status === "Rejected"
                          ? "error"
                          : "warning"
                    }
                  />
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </CardContent>
    )
}

export default AllRequestesOfCitizen