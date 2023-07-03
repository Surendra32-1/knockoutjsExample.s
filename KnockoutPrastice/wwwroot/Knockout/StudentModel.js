/// <reference path="knockout.js" />

function StudentModel(item)
{//takes data from api in item  and put in Id,Name,Address,Grade 
   let self = this;
    item = item || {};
    self.id = ko.observable(item.id || 0);
    self.name = ko.observable(item.name || "");
    self.address = ko.observable(item.address || "");
    self.grade = ko.observable(item.grade || 0);
    self.gender = ko.observable(item.gender ||"Male");
    self.schoolbranch = ko.observableArray(item.schoolbranch);
}