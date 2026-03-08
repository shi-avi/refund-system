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
        <>
            <CardContent>
                <Typography variant="h6" gutterBottom>
                    כל הבקשות של האזרח
                </Typography>

                <Divider sx={{ mb: 2 }} />

                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Request Id</TableCell>
                                <TableCell>Amount</TableCell>
                                <TableCell>Status</TableCell>
                            </TableRow>
                        </TableHead>

                        <TableBody>
                            {citizenRequests.map((req) => (
                                <TableRow key={req.requestId}>
                                    <TableCell>{req.requestId}</TableCell>
                                    <TableCell>{req.refundAmount}</TableCell>
                                    <TableCell>
                                        <Chip
                                            label={req.status}
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
        </>
    )
}

export default AllRequestesOfCitizen