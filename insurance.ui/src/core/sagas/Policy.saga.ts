import { call, put, takeLatest } from "redux-saga/effects";
import { FETCH_POLICY_TYPE_REQUEST, fetchPolicyTypeFailure, fetchPolicyTypeSuccess } from "../actions/policy.action";
import { ApiError, APIResponse } from "../interfaces/response";
import { PolicyType } from "../models/policy.model";
import { fetchPolicyTypes } from "../services/policy.service";

function* fetchPolicyTypeSaga() {
    try {
      const response: APIResponse<PolicyType[]> = yield call(fetchPolicyTypes);
  
      const policyTypes = response.data || [];
  
      // Check the success status
      if (response.isSuccess) {
        yield put(fetchPolicyTypeSuccess(policyTypes)); // Dispatch success with an array
      } else {
        const apiError: ApiError = response.error as ApiError;
        yield put(fetchPolicyTypeFailure(apiError));
      }
    } catch (error) {
      const apiError: ApiError = error as ApiError;
      yield put(fetchPolicyTypeFailure(apiError));
    }
  }

export function* watchPolicySaga() {
  yield takeLatest(FETCH_POLICY_TYPE_REQUEST, fetchPolicyTypeSaga);
}
