import {SET_SEARCH_RESULTS} from './actionTypes';

export function setSearchResult(result) {
  return {type: SET_SEARCH_RESULTS, result};
}
