function StudentController()
{ 
    var self = this;
    self.selectedStudent = ko.observable(new StudentModel());
    self.newStudent = ko.observable(new StudentModel());
    //initialize mode so 
    self.mode = ko.observable(mode.create);
    //for select options
    self.locations = ko.observableArray(["Bhw", "Taulihawa", "Lumbini", "Butwal", "Shankar nagar"]);
    //array for holding student
    self.AllStudents = ko.observableArray([]);
    //base url
    const baseUrl = "api/StudentModels";


    //GetAll student Data by calling baseurl and get result and map to knockoutjs from here return to AllStudents
    ajax.get(baseUrl).then(function (result) {
        var studentData = ko.utils.arrayMap(result, function (item) {
            return new StudentModel(item);
        });
        self.AllStudents(studentData);
    });


    //When add button and new data field then click this method is called read self.mode() value when 1 add otherwise update
    self.addStudent = function () {
        switch (self.mode()) {
            case 1:
                ajax.post(baseUrl, ko.toJSON(self.newStudent())).done(function (result) {
                    console.log(result)
                    self.AllStudents.push(new StudentModel(result));
                    //make form clear
                    self.resetForm();
                   
                }).fails((err) => {
                    console.log(err);
                });
                console.log(self.AllStudents());
                break;
            default:
//when edit data go in form and change self.mode()=2 add button pressed 
                ajax.put(baseUrl + "/" + self.newStudent().id(), ko.toJSON(self.newStudent())).done(function (result) {
                    self.AllStudents.replace(self.selectedStudent(), self.newStudent());
                    self.resetForm();
                    console.log(self.AllStudents());
                });
                break;
        }
    };

    //making form clear for add
    self.resetForm = function () {
        self.newStudent(new StudentModel());
        self.selectedStudent(new StudentModel());
        self.mode(mode.create);
    }

    
    //selecting particular row data for update
    self.editStudent = (model) => {
       // console.log(model);
        //putting model in variable that hold student object for edit purpose after converting to javascrpt
        self.selectedStudent(ko.toJS(model));
       // console.log(self.selectedStudent());
        //for displaying in form convert ko to javascript object and put in newStudent
        self.newStudent(new StudentModel(ko.toJS(model)));
      //  console.log(self.newStudent());
        //for update change button mode other wise create
        self.mode(mode.update);
    };

//method to Delete
    self.deleteStudent = (model) => {
        var studData = ko.toJS(model);
        ajax.delete(baseUrl + "/" + studData.id).done(function (result) {
             //console.log(model);
            self.AllStudents.remove(model);
            self.AllStudents();
        });
    };

}
//ajax methods
var ajax = {
    get: function (url, data) {
        return $.ajax({
            method: "GET",
            url: url,

        });
    }
    ,
    post: function (url, data) {

        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            url: url,
            data: (data)
        });
    },
    put: function (url, data) {
        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "PUT",
            url: url,
            data: data
        });
    },
    delete: function (url, id) {
        //api/apiController/id
        
        return $.ajax({
            method: "DELETE",
            url: url
           
        });

    }
}

//from here decide create or update
const mode = {
    create: 1,
    update: 2
};