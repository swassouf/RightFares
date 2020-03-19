"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DropDownData = /** @class */ (function () {
    function DropDownData() {
    }
    DropDownData.prototype.GetCountryOptions = function () {
        return fetch("/Portal/Common/GetCountries").then(function (result) { return result.json(); }).then(function (items) {
            return items;
        }).catch(function (error) {
            var err = error;
        });
    };
    DropDownData.prototype.GetStateOptions = function (countryId) {
        return fetch("/Portal/Common/GetStateProvinces?countryId=" + countryId).then(function (result) { return result.json(); }).then(function (items) {
            return items;
        }).catch(function (error) {
            var err = error;
        });
    };
    DropDownData.prototype.GetCities = function (stateId) {
        return fetch("/Portal/Common/GetCities?stateId=" + stateId).then(function (result) { return result.json(); }).then(function (items) {
            return items;
        }).catch(function (error) {
            var err = error;
        });
    };
    return DropDownData;
}());
exports.default = DropDownData;
//# sourceMappingURL=dropDownData.js.map