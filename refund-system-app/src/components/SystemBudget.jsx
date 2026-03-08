import { useEffect, useState } from "react";
import { Typography, Card, CardContent, Box } from "@mui/material";
import { getSystemBudget } from "../api/systemBudgetApi";

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
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
      <Card sx={{ minWidth: 300 }}>
        <CardContent>
          <Typography variant="h5" gutterBottom>
            תקציב המערכת
          </Typography>

          <Typography variant="h4">
            ₪ {budget.currentAmount}
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
}

export default SystemBudget;