import React, { useState } from "react";
import {
    TextField,
    Button,
    DialogTitle,
    DialogContent,
    Box,
    DialogActions
} from "@mui/material";
import { createRefundRequest } from "../api/refundApi"
import "../style/AddRefundRequest.css";

function AddRefundRequest({ id }) {

    const [year, setYear] = useState("");
    const [incomes, setIncomes] = useState([{ month: "", amount: "" }]);

    const addIncomeRow = () => {
        if (incomes.length < 12) {
            setIncomes([...incomes, { month: "", amount: "" }]);
        }
    };

    const handleIncomeChange = (index, field, value) => {
        const updated = [...incomes];
        updated[index][field] = value;
        setIncomes(updated);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newRefundRequest = {
            "citizenId": id,
            "year": year,
            incomes: incomes.map(i => ({
                month: Number(i.month),
                amount: Number(i.amount)
            }))
        };

        try {
            const result = await createRefundRequest(newRefundRequest);

            const refundAmount = result.estimatedRefund.refundAmount;

            alert(`סכום ההחזר המשוער הוא: ${refundAmount}`);
        } catch (error) {
            console.error(error);
        }
    };

    return (
<div className="add-refund-container">
            <DialogTitle className="add-refund-title">הוספת בקשת החזר חדשה</DialogTitle>

            <DialogContent sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}>
                <TextField
                    label="שנת מס"
                    fullWidth
                    margin="normal"
                    value={year}
                    onChange={(e) => setYear(e.target.value)}
                    className="add-refund-textfield"
                />

                {incomes.map((income, index) => (
                    <Box key={index} className="add-refund-row">
                        <TextField
                            label="חודש"
                            value={income.month}
                            onChange={(e) => handleIncomeChange(index, "month", e.target.value)}
                            className="add-refund-textfield"
                        />

                        <TextField
                            label="הכנסה חודשית"
                            value={income.amount}
                            onChange={(e) => handleIncomeChange(index, "amount", e.target.value)}
                            className="add-refund-textfield"
                        />
                    </Box>
                ))}

                <Button
                    variant="contained"
                    onClick={addIncomeRow}
                    disabled={incomes.length >= 12}
                    className="add-refund-button"
                >
                    +
                </Button>
            </DialogContent>

            <DialogActions>
                <Button
                    variant="contained"
                    onClick={handleSubmit}
                    className="add-refund-button"
                >
                    שמור
                </Button>
            </DialogActions>
        </div>
    );
}

export default AddRefundRequest;