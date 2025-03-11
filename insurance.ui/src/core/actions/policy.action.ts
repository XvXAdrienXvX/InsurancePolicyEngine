import { ApiError } from "../interfaces/response";
import { PolicyType } from "../models/policy.model";

export const FETCH_POLICY_TYPE_REQUEST = "FETCH_POLICY_TYPE_REQUEST";
export const FETCH_POLICY_TYPE_SUCCESS = "FETCH_POLICY_TYPE_SUCCESS";
export const FETCH_POLICY_TYPE_FAILURE = "FETCH_POLICY_TYPE_FAILURE";

// Action Interfaces
export interface FetchPolicyTypeRequestAction {
  type: typeof FETCH_POLICY_TYPE_REQUEST;
}

export interface FetchPolicyTypeSuccessAction {
  type: typeof FETCH_POLICY_TYPE_SUCCESS;
  payload: PolicyType[];
}

export interface FetchPolicyTypeFailureAction {
  type: typeof FETCH_POLICY_TYPE_FAILURE;
  payload: ApiError;
}

// Union Type for all Actions
export type PolicyActionTypes =
  | FetchPolicyTypeRequestAction
  | FetchPolicyTypeSuccessAction
  | FetchPolicyTypeFailureAction;

// Action Creators
export const fetchPolicyTypeRequest = (): FetchPolicyTypeRequestAction => ({
  type: FETCH_POLICY_TYPE_REQUEST,
});

export const fetchPolicyTypeSuccess = (
  policyTypes: PolicyType[]
): FetchPolicyTypeSuccessAction => ({
  type: FETCH_POLICY_TYPE_SUCCESS,
  payload: policyTypes,
});

export const fetchPolicyTypeFailure = (
  error: ApiError
): FetchPolicyTypeFailureAction => ({
  type: FETCH_POLICY_TYPE_FAILURE,
  payload: error,
});
