import apiClient from "./apiClient";

export const getPendingRefundRequests = async () => {
  const response = await apiClient.get("/RefundRequest/pending");
  return response.data;
};

export const getRefundRequestById = async (id) => {
  const response = await apiClient.get(`/RefundRequest/${id}`);
  return response.data;
};

export const getRefundRequestByCitizenId = async (citizenId) => {
  const response = await apiClient.get(`/RefundRequest/citizen/${citizenId}`);
  return response.data;
};

export const getLastRefundRequestByCitizenId = async (citizenId) => {
  const response = await apiClient.get(`/RefundRequest/citizen/${citizenId}/last`);
  return response.data;
};


export const createRefundRequest = async (refundRequestDto) => {
  const response = await apiClient.post("/RefundRequest", refundRequestDto);
  return response.data;
};

export const DoCalculation = async (CalculateRefundDto) => {
  const response = await apiClient.post("/RefundRequest/calculate", CalculateRefundDto);
  return response.data;
};

export const clerkDecision = async (ProcessRefundDto) => {
  const response = await apiClient.post("/RefundRequest/process", ProcessRefundDto);
  return response.data;
};

