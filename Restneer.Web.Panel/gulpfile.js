const path       = require('path');
const gulp       = require('gulp');
const uglify     = require('gulp-uglify');
const concat     = require('gulp-concat');
const rev        = require('gulp-rev');
const order      = require("gulp-order");
const sourcemaps = require('gulp-sourcemaps');
const minifyCss  = require('gulp-minify-css');

const BASE_URL   = path.join(__dirname, "wwwroot");
console.log(BASE_URL);
gulp.task('minify-css', function () {
    return gulp.src([
        path.join(BASE_URL, 'css', 'bootstrap.min.css'),
        path.join(BASE_URL, 'css', 'font-awesome.min.css'),
        path.join(BASE_URL, 'css', 'smartadmin-production.min.css'),
        path.join(BASE_URL, 'css', 'smartadmin-skins.min.css')
    ])
    .pipe(sourcemaps.init())
    .pipe(minifyCss({
        compatibility: 'ie8'
    }))
    .pipe(concat({
        path: 'bundle.min.css',
        cwd: ''
     }))
    //.pipe(rev())
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest(BASE_URL));
});
