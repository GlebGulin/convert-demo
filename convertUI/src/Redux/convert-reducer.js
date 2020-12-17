const SET_HISTORY="SET_HISTORY";
const SET_CURRENCIES="SET_CURRENCIES";
let initialState = {
    historyData: [],
    currencies:[]
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
      default:
           return state;
    }
}
export const setHistory = (historyData) => ({type: SET_HISTORY, historyData});
export const setCurrencies = (currencies) => ({type: SET_CURRENCIES, currencies});
export default ConvertReducer;
