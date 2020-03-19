"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DropDownData = (function () {
    function DropDownData() {
    }
    DropDownData.prototype.GetCountryOptions = function () {
        return fetch("/Common/GetCountries").then(function (result) { return result.json(); }).then(function (items) {
            return items;
        }).catch(function (error) {
            var err = error;
        });
    };
    return DropDownData;
}());
exports.default = DropDownData;
//# sourceMappingURL=dropDownData.js.map