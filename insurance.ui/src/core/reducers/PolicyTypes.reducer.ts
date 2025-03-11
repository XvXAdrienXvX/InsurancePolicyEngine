import {
  FETCH_POLICY_TYPE_FAILURE,
  FETCH_POLICY_TYPE_REQUEST,
  FETCH_POLICY_TYPE_SUCCESS,
  PolicyActionTypes,
} from "../actions/policy.action";
import { ApiError } from "../interfaces/response";
import { PolicyType } from "../models/policy.model";

interface PolicyState {
  policyTypes: PolicyType[];
  loading: boolean;
  error: ApiError | null;
}

const initialState: PolicyState = {
  policyTypes: [],
  loading: false,
  error: null,
};

const PolicyTypeReducer = (
  state = initialState,
  action: PolicyActionTypes
): PolicyState => {
  switch (action.type) {
    case FETCH_POLICY_TYPE_REQUEST:
      return { ...state, loading: true };

    case FETCH_POLICY_TYPE_SUCCESS:
      return { ...state, loading: false, policyTypes: action.payload };

    case FETCH_POLICY_TYPE_FAILURE:
      return { ...state, loading: false, error: action.payload };

    default:
      return state;
  }
};

export default PolicyTypeReducer;