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
		<>
			<CardContent>
				<Typography variant="h6" gutterBottom>
					הכנסות לפי שנים
				</Typography>

				<Divider sx={{ mb: 2 }} />

				<TableContainer component={Paper}>
					<Table>
						<TableHead>
							<TableRow>
								<TableCell>Year</TableCell>
								<TableCell align="right">Total Income</TableCell>
							</TableRow>
						</TableHead>

						<TableBody>
							{incomes.map((income) => (
								<TableRow key={income.year}>
									<TableCell>{income.year}</TableCell>
									<TableCell align="right">
										₪ {income.totalIncome}
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

export default IncomesOfCitizen