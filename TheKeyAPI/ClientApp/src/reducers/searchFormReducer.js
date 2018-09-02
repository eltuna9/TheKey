import {SET_SEARCH_RESULTS} from '../actions/actionTypes';

export default function searchReducer(state = null, action) {
  switch (action.type) {
    case SET_SEARCH_RESULTS: {
      return Object.assign({}, state, action.result);
    }
    default: {
      return state;
    }
  }
}
