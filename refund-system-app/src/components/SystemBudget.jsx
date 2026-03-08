import { useEffect, useState } from "react";
import { Typography, Card, CardContent, Box } from "@mui/material";
import { getSystemBudget } from "../api/systemBudgetApi";
import "../style/SystemBudget.css";

function SystemBudget(refreshBudget) {
  const [budget, setBudget] = useState(null);

  useEffect(() => {
    const fetchBudget = async () => {
      try {
        const data = await getSystemBudget();
        setBudget(data);
      } catch (error) {
        console.error("Error fetching budget:", error);
      }
    };

    fetchBudget();
  }, [refreshBudget]);

  if (!budget) return <div>טוען תקציב...</div>;

  return (
    <Box className="system-budget-container">
      <Card className="system-budget-card">
        <CardContent>
          <Typography variant="h5" className="system-budget-title">
            תקציב המערכת
          </Typography>

          <Typography variant="h4" className="system-budget-amount">
            ₪ {budget.currentAmount}
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
}

export default SystemBudget;