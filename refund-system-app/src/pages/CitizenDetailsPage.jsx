import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
	Container,
	Typography,
	Card,
	CardContent,
	Stack,
	Divider
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
<div className="page-container">

			<Container maxWidth="lg">

				<SystemBudget refreshBudget={refreshBudget} />

				{/* <Typography variant="h4" className="page-title">
					פרטי אזרח
				</Typography> */}

				<Stack spacing={3}>

					{/* פרטי אזרח */}
					<Card className="card-section">
						<CardContent>
							<Typography className="citizen-name">
								{citizen?.fullName}
							</Typography>
						</CardContent>
					</Card>

					{/* בקשה נבחרת */}
					{/* <Card className="card-section">
						<CardContent>
							<Typography className="card-header">
								בקשה נוכחית
							</Typography>

							<Divider sx={{ mb: 2 }} /> */}

							<CurrentRequest
								requestId={requestId}
								setRefreshBudget={setRefreshBudget}
							/>
						{/* </CardContent>
					</Card> */}

					{/* הכנסות */}
					{/* <Card className="card-section">
						<CardContent>
							<Typography className="card-header">
								הכנסות האזרח
							</Typography>

							<Divider sx={{ mb: 2 }} /> */}

							<IncomesOfCitizen citizenId={citizenId} />
						{/* </CardContent>
					</Card> */}

					{/* כל הבקשות */}
					{/* <Card className="card-section">
						<CardContent>
							<Typography className="card-header">
								כל הבקשות
							</Typography>

							<Divider sx={{ mb: 2 }} /> */}

							<AllRequestesOfCitizen citizenId={citizenId} />
						{/* </CardContent>
					</Card> */}

				</Stack>

			</Container>

		</div>
	)
}

export default CitizenDetailsPage
