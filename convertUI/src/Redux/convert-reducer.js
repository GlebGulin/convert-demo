const SET_HISTORY="SET_HISTORY";
const SET_CURRENCIES="SET_CURRENCIES";
const CHANGE_AMOUNT = "CHANGE_AMOUNT";
const ADD_NEW_ITEM = "ADD_NEW_ITEM";

let initialState = {
    
    historyData: [],
    currencies:[],
    
    fromAmount: 0,
    fromCurrencyId: 1,
    toAmount: 0,
    toCurrencyId: 1
}

const ConvertReducer = (state = initialState, action) =>{
    debugger;
    switch(action.type){
        
        case SET_HISTORY:
            debugger;
            return{
                
                ...state,
                historyData: action.historyData
                
               
            }
        case SET_CURRENCIES:
            debugger;
            return{
                ...state,
                currencies: action.currencies
                
            }
        case CHANGE_AMOUNT:
            return{
                ...state,
                fromAmount: action.newAmount
            }
        case ADD_NEW_ITEM:
            return{
                ...state,
                historyData:[...state.historyData, {...state.fromAmount, ...state.fromCurrencyId,...state.toCurrencyId}]
            }
      default:
           return state;
    }
}
export const setHistory = (historyData) => ({type: SET_HISTORY, historyData});
export const setCurrencies = (currencies) => ({type: SET_CURRENCIES, currencies});
export const changeAmount = (newAmount) => ({type: CHANGE_AMOUNT, newAmount});
export const addNewItem = () => ({type: ADD_NEW_ITEM})
export default ConvertReducer;
