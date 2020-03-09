window.Filters = function () {
    var EntryDate,
        LeavingDate,
        AdultNumbers,
        MinorNumbers,
        MinimumPrice,
        MaximumPrice,
        City;

    this.hasEntryDate = function () {
        return EntryDate !== undefined;
    };

    this.getEntryDateAfterHas = function () {
        return EntryDate;
    }

    this.setEntryDate = function (v) {
        EntryDate = v;
    }

    this.unsetLeavingDate = function () {
        LeavingDate = undefined;
    }

    this.hasLeavingDate = function () {
        return LeavingDate !== undefined;
    };

    this.getLeavingDateAfterHas = function () {
        return LeavingDate;
    }

    this.setLeavingDate = function (v) {
        LeavingDate = v;
    }

    this.unsetLeavingDate = function () {
        LeavingDate = undefined;
    }

    this.hasAdultNumbers = function () {
        return AdultNumbers !== undefined;
    };

    this.getAdultNumbersAfterHas = function () {
        return AdultNumbers;
    }

    this.setAdultNumbers = function (v) {
        AdultNumbers = v;
    }

    this.unsetAdultNumbers = function () {
        AdultNumbers = undefined;
    }

    this.hasMinorNumbers = function () {
        return MinorNumbers !== undefined;
    };

    this.getMinorNumbersAfterHas = function () {
        return MinorNumbers;
    }

    this.setMinorNumbers = function (v) {
        MinorNumbers = v;
    }

    this.unsetMinorNumbers = function () {
        MinorNumbers = undefined;
    }

    this.hasMinimumPrice = function () {
        return MinimumPrice !== undefined;
    };

    this.getMinimumPriceAfterHas = function () {
        return MinimumPrice;
    }

    this.setMinimumPrice = function (v) {
        MinimumPrice = v;
    }

    this.unsetMinimumPrice = function () {
        MinimumPrice = undefined;
    }

    this.hasMaximumPrice = function () {
        return MaximumPrice !== undefined;
    };

    this.getMaximumPriceAfterHas = function () {
        return MaximumPrice;
    }

    this.setMaximumPrice = function (v) {
        MaximumPrice = v;
    }

    this.unsetMaximumPrice = function () {
        MaximumPrice = undefined;
    }

    this.hasCity = function () {
        return City !== undefined;
    };

    this.getCityAfterHas = function () {
        return City;
    }

    this.setCity = function (v) {
        City = v;
    }

    this.unsetCity = function () {
        City = undefined;
    }
}