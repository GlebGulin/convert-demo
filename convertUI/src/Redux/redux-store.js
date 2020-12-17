import {createStore, combineReducers} from 'redux';
import ConvertReducer from './convert-reducer';

debugger;
let reducers = combineReducers({
    convertPage: ConvertReducer
   
}); 
let store = createStore(reducers);
window.store = store;
export default store;