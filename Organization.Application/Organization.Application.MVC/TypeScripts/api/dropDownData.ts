import SelectOption from "./selectOption";

export default class DropDownData {
    constructor() {

    }

    GetCountryOptions() {


        return fetch("/Portal/Common/GetCountries").then(result => result.json()).then(items => {
            return items;

        }).catch(error => {
            let err = error;
        })

    }

    GetStateOptions(countryId: number) {

        return fetch("/Portal/Common/GetStateProvinces?countryId=" + countryId).then(result => result.json()).then(items => {
            return items;

        }).catch(error => {
            let err = error;
        })

    }

    GetCities(stateId: number) {

        return fetch("/Portal/Common/GetCities?stateId=" + stateId).then(result => result.json()).then(items => {
            return items;

        }).catch(error => {
            let err = error;
        })
    }
}