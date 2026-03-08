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
	Divider,
} from "@mui/material";
import { getIncomeByCitizenByYear } from "../api/incomeApi"
import "../style/IncomesOfCitizen.css";


function IncomesOfCitizen({ citizenId }) {

	const [incomes, setIncomes] = useState([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				const incomesRes = await getIncomeByCitizenByYear(citizenId);
				setIncomes(incomesRes);
			} catch (error) {
				console.log(error);
			}
		};
		fetchData();
	}, [citizenId]);

	return (
		<CardContent className="incomes-container">
      <Typography variant="h6" gutterBottom className="incomes-title">
        הכנסות לפי שנים
      </Typography>

      <Divider sx={{ mb: 2 }} />

      <TableContainer component={Paper}>
        <Table className="incomes-table">
          <TableHead>
            <TableRow>
              <TableCell align="right">שנה</TableCell>
              <TableCell align="right">סך ההכנסות</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {incomes.map((income) => (
              <TableRow key={income.year}>
                <TableCell align="right">{income.year}</TableCell>
                <TableCell align="right">₪ {income.totalIncome}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </CardContent>
	)
}

export default IncomesOfCitizen