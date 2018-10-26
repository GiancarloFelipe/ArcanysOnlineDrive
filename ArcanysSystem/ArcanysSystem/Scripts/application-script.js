$(document).ready(function () {
    "use strick"

    Dropzone.options.dropzoneForm = {
        init: function () {
            var myDropzone = this;
            this.on("complete", function (data) {
                try {
                    var res = JSON.parse(data.xhr.responseText);
                    console.log(res.Message);
                } catch (e) {
                    console.log(e);
                }
            });
        }
    };

    $(".datepicker").datepicker({
        format: 'mm/dd/yyyy',
    });

    //var url = window.location.href;
    var activeTab = window.location.pathname;

    $(".nav-link").removeClass("active");
    $('a[href="' + activeTab + '"]').addClass("active");

    $(".nav-item").removeClass("active");
    //$('li[title="' + activeTab + '"]').addClass("active");


    findSideMenu(activeTab);
    function findSideMenu(pathname) {
        var _pathname = pathname;
        for (var i = _pathname.length; i > 0; i--) {
            try {
                if ($('li[title="' + _pathname.substr(0, i) + '"]').attr("title") != undefined) {
                    //alert('Title: ' + $('li[title="' + _pathname.substr(0, i) + '"]').attr("title"));
                    if ($('li[title="' + _pathname.substr(0, i) + '"]').attr("title") == _pathname.substr(0, i)) {
                        //alert('FOUND IT BOY');
                        $('li[title="' + _pathname.substr(0, i) + '"]').addClass("active");
                        break;
                    }
                }
            } catch (e) { }
        }
    }

    function pad(value, length) {
        var _value = '' + value;
        while (_value.length < length) {
            _value = '0' + _value;
        }
        return _value;
    }

    function calculateAge(birthdate) {
        var _currentDate = new Date();
        var _inputBirthDate = birthdate.split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _day = _birthdate.getDate();
        var _month = _birthdate.getMonth();
        var _year = _birthdate.getFullYear();
        var _age;
        // Check Normal Date...
        _age = parseInt(_currentDate.getFullYear()) - parseInt(_year);
        // Check Current Month & Date...
        if (
            (parseInt(_month) < parseInt(_currentDate.getMonth())) ||
            ((parseInt(_month) <= parseInt(_currentDate.getMonth())) && (parseInt(_day) <= parseInt(_currentDate.getDate())))
        ) {
            _age = parseInt(_currentDate.getFullYear()) - parseInt(_year);
            //alert(_month + "/" + _day + " | Less than Equals Today | " + _currentDate.getMonth() + "/" + _currentDate.getDate() + " AGE: " + _age);
        } else {
            _age = parseInt(_currentDate.getFullYear()) - parseInt(_year) - 1;
            //alert(_month + "/" + _day + " | Greater than Today | " + _currentDate.getMonth() + "/" + _currentDate.getDate() + " AGE: " + _age);
        }
        // Check Leap Year...
        if (parseInt(_month) === 1) {
            if (parseInt(_day) > 28) {
                _age = parseInt(parseInt(parseInt(_currentDate.getFullYear()) - (parseInt(_currentDate.getFullYear()) - (((Math.floor((parseInt(_currentDate.getFullYear()) / 4)) * 4) - parseInt(_year)) / 4))));
                //alert(_month + "/" + _day + " | Leap Year | " + _currentDate.getMonth() + "/" + _currentDate.getDate() + " AGE: " + _age);
            }
        }
        return parseInt(_age);
    }

    var datepicker = $(".datepicker").change(function () {
        if ($("#BirthDate").val() === "") {
            $("#BirthDate").val("01/01/1900");
        }
        var _inputBirthDate = $("#BirthDate").val().split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _dateLimit = new Date(1899, 0, 1);
        if (parseInt(_birthdate.getFullYear()) < parseInt(_dateLimit.getFullYear())) {
            alert("Your selected date range is getting to low. The lowest 'Date' range allowed was until '01/01/1900' only... or it will be forced by the system to year 19'th.");
            if (_birthdate < 100) {
                $("#BirthDate").val(pad((parseInt(_birthdate.getMonth()) + 1), 2) + '/' + pad(_birthdate.getDate(), 2) + '/' + pad("1900", 4));
                $("#Age").val(calculateAge($("#BirthDate").val()));
            }
        } else {
            $("#BirthDate").val(pad((parseInt(_birthdate.getMonth()) + 1), 2) + '/' + pad(_birthdate.getDate(), 2) + '/' + pad(_birthdate.getFullYear(), 4));
        }
    });

    var computeAge = $("#BirthDate").change(function () {
        var bdate = $(this).val();
        if ($(this).val() === "") {
            $(this).val("01/01/1900");
        }
        $("#Age").val(calculateAge($(this).val()));
    });

    function calculateAgeYear(birthdate, age) {
        var _currentDate = new Date();
        var _inputAge = age;
        var _inputBirthDate = birthdate.split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _day = _birthdate.getDate();
        var _month = _birthdate.getMonth();
        var _year = _birthdate.getFullYear();

        var _ageYear;
        // Check Current Month & Date...
        if (
            (parseInt(_month) < parseInt(_currentDate.getMonth())) ||
            ((parseInt(_month) <= parseInt(_currentDate.getMonth())) && (parseInt(_day) <= parseInt(_currentDate.getDate())))
        ) {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge);
        } else {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge) - 1;
        }

        // Check Leap Year...
        if (parseInt(_month) === 1) {
            if (parseInt(_day) > 28) {
                _ageYear = (Math.floor((parseInt(_currentDate.getFullYear()) / 4)) * 4) - (parseInt(_inputAge) * 4);
            }
        }
        //alert(_ageYear);
        return _ageYear;
    }

    // AGE:
    var computeBirthDate = $("#Age").change(function () {
        var _inputAge = $("#Age").val();
        var _inputBirthDate = $("#BirthDate").val().split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _day = _birthdate.getDate();
        var _month = _birthdate.getMonth();
        var _ageLimit = 300;

        if (_inputAge == "" || _inputAge == undefined || parseInt(_inputAge) < 0) {
            _inputAge = 0;
            $("#Age").val(_inputAge);
        }
        if (_inputAge > _ageLimit) {
            alert("Your input 'Age' range is getting to high. The age range limit was only until 300 years old...");
            $("#Age").val(_ageLimit);
        }

        var _newbirthdate = new Date(calculateAgeYear($("#BirthDate").val(), $(this).val()), _month, _day);

        if (parseInt(_day) === parseInt(_newbirthdate.getDate())) {
            $("#BirthDate").val(pad((parseInt(_newbirthdate.getMonth()) + 1), 2) + '/' + pad(_newbirthdate.getDate(), 2) + '/' + pad(_newbirthdate.getFullYear(), 4));
        } else {
            $("#BirthDate").val("02" + '/' + "28" + '/' + pad(_newbirthdate.getFullYear(), 4));
            $("#Age").val(calculateAge($("#BirthDate").val()));
        }
    });

    // AGE MINUS:
    var computeBirthDate = $("#AgeMinus").click(function () {
        var _currentDate = new Date();
        var _inputAge = $("#Age").val();
        var _min = $("#Age").attr("min");
        var _inputBirthDate = $("#BirthDate").val().split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _day = _birthdate.getDate();
        var _month = _birthdate.getMonth();
        var _year = _birthdate.getFullYear();

        if (parseInt(_inputAge) <= parseInt(_min))
            return;

        var _ageYear;
        if (
            (parseInt(_month) < parseInt(_currentDate.getMonth())) ||
            ((parseInt(_month) <= parseInt(_currentDate.getMonth())) && (parseInt(_day) <= parseInt(_currentDate.getDate())))
        ) {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge) + 1;
        } else {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge);
        }

        // Check Leap Year...
        if (parseInt(_month) === 1) {
            if (parseInt(_day) > 28) {
                _ageYear = (Math.floor((parseInt(_currentDate.getFullYear()) / 4)) * 4) - ((parseInt(_inputAge) - 1) * 4);
            }
        }

        var _newbirthdate = new Date(_ageYear, _month, _day);

        if (parseInt(_day) === parseInt(_newbirthdate.getDate())) {
            $("#BirthDate").val(pad((parseInt(_newbirthdate.getMonth()) + 1), 2) + '/' + pad(_newbirthdate.getDate(), 2) + '/' + pad(_newbirthdate.getFullYear(), 4));
        } else {
            $("#BirthDate").val("02" + '/' + "28" + '/' + pad(_newbirthdate.getFullYear(), 4));
            $("#Age").val(calculateAge($("#BirthDate").val()));
        }
    });

    // AGE PLUS:
    var computeBirthDate = $("#AgePlus").click(function () {
        var _currentDate = new Date();
        var _inputAge = $("#Age").val();
        var _max = $("#Age").attr('max');
        var _inputBirthDate = $("#BirthDate").val().split("/");
        var _birthdate = new Date(_inputBirthDate[2], _inputBirthDate[0] - 1, _inputBirthDate[1]);
        var _day = _birthdate.getDate();
        var _month = _birthdate.getMonth();
        var _year = _birthdate.getFullYear();

        if (parseInt(_inputAge) >= parseInt(_max))
            return;

        var _ageYear;
        if (
            (parseInt(_month) < parseInt(_currentDate.getMonth())) ||
            ((parseInt(_month) <= parseInt(_currentDate.getMonth())) && (parseInt(_day) <= parseInt(_currentDate.getDate())))
        ) {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge) - 1;
        } else {
            _ageYear = parseInt(_currentDate.getFullYear()) - parseInt(_inputAge) - 2;
        }

        // Check Leap Year...
        if (parseInt(_month) === 1) {
            if (parseInt(_day) > 28) {
                _ageYear = (Math.floor((parseInt(_currentDate.getFullYear()) / 4)) * 4) - ((parseInt(_inputAge) + 1) * 4);
            }
        }

        var _newbirthdate = new Date(_ageYear, _month, _day)

        if (parseInt(_day) === parseInt(_newbirthdate.getDate())) {
            $("#BirthDate").val(pad((parseInt(_newbirthdate.getMonth()) + 1), 2) + '/' + pad(_newbirthdate.getDate(), 2) + '/' + pad(_newbirthdate.getFullYear(), 4));
        } else {
            $("#BirthDate").val("02" + '/' + "28" + '/' + pad(_newbirthdate.getFullYear(), 4));
            $("#Age").val(calculateAge($("#BirthDate").val()));
        }
    });
});

$(function () {
    $('.spinner .btn:last-of-type').on('click', function () {
        var _btn = $(this);
        var _input = _btn.closest('.spinner').find('input');
        if (_input.attr('max') == undefined || parseInt(_input.val()) < parseInt(_input.attr('max'))) {
            _input.val(parseInt(_input.val(), 10) + 1);
        } else if (!$.isNumeric(_input.val())) {
            _input.val(0);

        } else {
            _btn.next("disabled", true);

        }
    });
    $('.spinner .btn:first-of-type').on('click', function () {
        var _btn = $(this);
        var _input = _btn.closest('.spinner').find('input');
        if (_input.attr('min') == undefined || parseInt(_input.val()) > parseInt(_input.attr('min'))) {
            _input.val(parseInt(_input.val(), 10) - 1);
        } else if (!$.isNumeric(_input.val())) {
            _input.val(0);

        } else {
            _btn.prev("disabled", true);

        }
    });
})

$(".numeric").keypress(function (event) {
    if (!((event.which >= 48 && event.which <= 57) || (event.which >= 8 && event.which <= 9) || (event.which === 13) || (event.which === 144) || (event.keyCode === 9))) {
        event.preventDefault();
    }
})

$(".name").keypress(function (event) {
    if (!((event.which >= 97 && event.which <= 122) || (event.which >= 65 && event.which <= 90) || (event.which >= 8 && event.which <= 9) || (event.which === 13) || (event.which === 144) || (event.which === 46) || (event.which === 32) || (event.which === 16) || (event.keyCode === 9))) {
        event.preventDefault();
    }
})

$(".datepicker").keypress(function (event) {
    if (!((event.which >= 48 && event.which <= 57) || (event.which === 13) || (event.which === 144) || (event.which === 47) || (event.keyCode === 9))) {
        event.preventDefault();
    }
})

