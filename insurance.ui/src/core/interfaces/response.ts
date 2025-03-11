export interface ApiError {
  isSuccess: boolean;
  error: {
    message: string;
  };
}

export interface APIResponse<T> {
  isSuccess: boolean;
  error: ApiError | null;
  data: T | null;
}

export const ApiErrorMessages = {
  noDataFound: "No data found",
};
