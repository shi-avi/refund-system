import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
	Container,
	Typography,
	Card,
	CardContent,
	Stack
} from "@mui/material";
import { getCitizenById } from "../api/citizenApi";
import SystemBudget from "../components/SystemBudget";
import CurrentRequest from "../components/CurrentRequest";
import IncomesOfCitizen from "../components/IncomesOfCitizen";
import AllRequestesOfCitizen from "../components/AllRequestesOfCitizen";

function CitizenDetailsPage() {

	const { citizenId, requestId } = useParams();
	const [refreshBudget, setRefreshBudget] = useState(false);
	const [citizen, setCitizen] = useState();

	useEffect(() => {

		const fetchData = async () => {
			try {
				const nameCitizen = await getCitizenById(citizenId);
				setCitizen(nameCitizen);
			} catch (error) {
				console.log(error);
			}
		};

		fetchData();

	}, [citizenId, requestId]);
	return (


		<Container maxWidth="md" sx={{ mt: 4 }}>
			<SystemBudget refreshBudget={refreshBudget} />

			<Typography variant="h4" fontWeight="bold" gutterBottom>
				פרטי אזרח
			</Typography>

			<Stack spacing={3}>

				{/* פרטי אזרח */}
				<Card>
					<CardContent>
						<Typography variant="h5">{citizen?.fullName}</Typography>
					</CardContent>
				</Card>

				{/* בקשה נבחרת */}
				<Card>
					<CurrentRequest requestId={requestId} setRefreshBudget={setRefreshBudget} />
				</Card>

				{/* הכנסות */}
				<Card>
					<IncomesOfCitizen citizenId={citizenId} />
				</Card>

				{/* כל הבקשות */}
				<Card>
					<AllRequestesOfCitizen citizenId={citizenId} />
				</Card>

			</Stack>

		</Container>
	)
}

export default CitizenDetailsPage
