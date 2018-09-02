import {combineReducers} from 'redux';
import searchResultReducer from './searchResultReducer';

const rootReducer = combineReducers({
  search: searchResultReducer
});

export default rootReducer;
