/// <binding Clean='clean' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    mainBowerFiles = require('main-bower-files');
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    project = require("./project.json"),
    concatVendor = require("gulp-concat-vendor");

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "lib/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "lib/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/vendor.min.js";
paths.concatCssDest = paths.webroot + "css/vendor.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src(mainBowerFiles("**/*.js"), { base: "./wwwroot/lib/" })
        .pipe(concatVendor(paths.concatJsDest))
        //.pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src(mainBowerFiles("**/*.css"), { base: "./wwwroot/lib/" })
        .pipe(concat(paths.concatCssDest))
        //.pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
