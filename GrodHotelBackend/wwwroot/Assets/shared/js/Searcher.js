window.Searcher = function () {
    var
        successCallback = function () { },
        errorCallback = function () { },
        alwaysCallback = function () { }
        ;

    this.setSuccessCallback = function (callback) {
        successCallback = callback;
    }

    this.setErrorCallback = function (callback) {
        errorCallback = callback;
    }

    this.setAlwaysCallback = function (callback) {
        alwaysCallback = callback;
    }

    this.search = function (filters) {
        var
            url = '/ApiSearch',
            options = {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: 'POST',
                body: buildJsonByFilters(filters)
            }
            ;

        fetch(
            url,
            options
        )
            .then(function (response) {
                //
                //                      Si necessiteu debuggejar el que vos torna el servidor:
                /*
                                  var promise = response.text();
                                  promise.then(
                                      function (text)
                                      {
                                          console.dir(text);
                                      }
                                  );
                */

                var promise = response.json();
                promise.then(
                    function (json) {
                        successCallback(json.rooms);
                    }
                );
            })
            .catch(function (error) {
                errorCallback(error);
            })
            .finally(function () {
                alwaysCallback();
            })
            ;
    }

    var buildJsonByFilters = function (filters) {
        var filtersPlain = {};

        if (filters.hasEntryDate()) {
            filtersPlain.EntryDate = filters.getEntryDateAfterHas();
        }
        if (filters.hasLeavingDate()) {
            filtersPlain.LeavingDate = filters.getLeavingDateAfterHas();
        }
        if (filters.hasAdultNumbers()) {
            filtersPlain.AdultNumbers = filters.getAdultNumbersAfterHas();
        }
        if (filters.hasMinorNumbers()) {
            filtersPlain.MinorNumbers = filters.getMinorNumbersAfterHas();
        }
        if (filters.hasMinimumPrice()) {
            filtersPlain.MinimumPrice = filters.getMinimumPriceAfterHas();
        }
        if (filters.hasMaximumPrice()) {
            filtersPlain.MaximumPrice = filters.getMaximumPriceAfterHas();
        }
        if (filters.hasCity()) {
            filtersPlain.City = filters.getCityAfterHas();
        }

        return JSON.stringify(filtersPlain);
    }
};