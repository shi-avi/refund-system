import { useEffect, useState } from "react";
import {
	Typography,
	CardContent,
	Chip,
	Divider,
	Button,
	Dialog,
	DialogTitle,
	DialogActions
} from "@mui/material";
import { getRefundRequestById, DoCalculation, clerkDecision } from '../api/refundApi'
import "../style/CurrentRequest.css";

function CurrentRequest({ requestId, setRefreshBudget }) {
	const [currentRequest, setCurrentRequest] = useState(null);
	const [open, setOpen] = useState(false);
	const [refundAmount, setRefundAmount] = useState(null);
	const [errorMessage, setErrorMessage] = useState(null);

	useEffect(() => {
		loadRequest();
	}, [requestId]);

	const handleSubmit = async () => {
		const newCalculation = {
			"citizenId": currentRequest.citizenId,
			"year": currentRequest.year
		};

		try {
			const result = await DoCalculation(newCalculation);
			setRefundAmount(result.refundAmount);
			setErrorMessage(null);
		} catch (error) {
			if (error.response && error.response.data) {
				setErrorMessage(error.response.data);
			} else {
				setErrorMessage("שגיאה בחישוב ההחזר");
			}
			setRefundAmount(null);
		}
		setOpen(true);
	};

	const clerkDecisionAction = async (e) => {
		setOpen(false)
		const newClerkDecision = {
			"requestId": requestId,
			"clerkDecision": e
		};

		try {
			await clerkDecision(newClerkDecision);
			await loadRequest();


		} catch (error) {
			console.error(error.response.data);
		}
	};

	const loadRequest = async () => {
		try {
			const requestRes = await getRefundRequestById(requestId);
			setCurrentRequest(requestRes);
			setRefreshBudget(true)
		} catch (error) {
			console.log(error);
		}
	};

	function formatDate(dateString) {
  if (!dateString) return "";
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const day = String(date.getDate()).padStart(2, "0");
  return `${year}-${month}-${day}`;
}

	return (
		
    <div className="current-request-container">
      <CardContent>
        <Typography variant="h6" className="current-request-title">
          בקשה נבחרת
        </Typography>

        <Divider sx={{ mb: 2 }} />

        {currentRequest ? (
          <div className="current-request-info">
            <Typography>
              <b>מספר בקשה:</b> {currentRequest.requestId}
            </Typography>

            <Typography>
              <b>תאריך:</b> {formatDate(currentRequest.createdAt)}
            </Typography>

            <Typography component="div" sx={{ mt: 1 }} >
              <b>סטטוס:</b>{" "}
              <Chip
                label={currentRequest.status}
                className="current-request-chip"
                color={
                  currentRequest.status === "Approved"
                    ? "success"
                    : currentRequest.status === "Rejected"
                      ? "error"
                      : "warning"
                }
              />
            </Typography>

            <Button
              variant="contained"
              className="current-request-button"
              onClick={handleSubmit}
            >
              בצע חישוב החזר
            </Button>
          </div>
        ) : (
          <Typography>אין בקשה</Typography>
        )}
      </CardContent>

      <Dialog open={open} onClose={() => setOpen(false)}>
        <DialogTitle className="current-request-dialog">סכום החזר</DialogTitle>

        <Typography variant="h4" textAlign="center" sx={{ mb: 2 }}>
          {refundAmount && (
            <Typography variant="h4">{refundAmount}</Typography>
          )}

          {errorMessage && (
            <Typography color="error">{errorMessage}</Typography>
          )}
        </Typography>

        <DialogActions sx={{ justifyContent: "center", mb: 2 }}>
          <Button variant="contained" onClick={() => clerkDecisionAction(true)}>
            אשר בקשה
          </Button>
          <Button variant="contained" onClick={() => clerkDecisionAction(false)}>
            דחה בקשה
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  
	)
}

export default CurrentRequest