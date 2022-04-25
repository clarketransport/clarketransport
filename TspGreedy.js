
function Point(id, lat, lon) {
    this.id = id;
    this.lat = lat;
    this.lon = lon;
};

function distance(p, q) {
    var f1 = p.lat * Math.PI / 180;
    var f2 = q.lat * Math.PI / 180;
    var df = (q.lon - p.lon) * Math.PI / 180;
    var R = 6371e3;
    var d = Math.acos(Math.sin(f1) * Math.sin(f2) + Math.cos(f1) * Math.cos(f2) * Math.cos(df)) * R;
    return d;
}

function Path(points) {
    this.points = points;
    this.length = points.length;
    this.route = new Array(this.length);
    for (var i = 0; i < this.length; i++) this.route[i] = i;
    this.tsp = new Array(this.length);
    for (var i = 0; i < this.length; i++) {
        this.distances = new Array(this.length);
        for (var j = 0; j < length; j++) {
            this.distances[j] = distance(points[i], points[j]);
        }
        this.tsp.push[distances];
    }
}


function Path() {
    this.length = 5;
    this.route = new Array(this.length);
    for (var i = 0; i < this.length; i++) this.route[i] = i;
	this.tsp = [ [ 0, 10, 15, 20, 33 ],
				 [ 10, 0, 35, 25, 36 ],
				 [ 15, 35, 0, 30, 37 ],
				 [ 20, 25, 30, 0, 38 ],
				 [ 33, 36, 37, 38, 0 ]
			   ];
}


Path.prototype.findMinRoute = function () {
    var sum = 0;
    var counter = 0;
    var j = 0, i = 0;
    var min = 2000000000;

    var visitedRouteList = [];
    // Starting from the 0th indexed
    // city i.e., the first city
    visitedRouteList.push(0);

	// Traverse the adjacency
	// matrix tsp[,]
	while (i < this.tsp[0].length &&
		j < this.tsp[1].length) {

		// Corner of the Matrix
		if (counter >= this.tsp[0].length - 1) {
			break;
		}

		// If this path is unvisited then
		// and if the cost is less then
		// update the cost
		if (j != i &&
			!(visitedRouteList.includes(j))) {
			if (this.tsp[i][j] < min) {
				min = this.tsp[i][j];
				this.route[counter] = j + 1;
			}
		}
		j++;

		// Check all paths from the
		// ith indexed city
		if (j == this.tsp[0].length) {
			sum += min;
			min = 2000000000;
			visitedRouteList.push(this.route[counter] - 1);

			j = 0;
			i = this.route[counter] - 1;
			counter++;
		}
	}

	i = this.route[counter - 1] - 1;

	for (j = 0; j < this.tsp[0].length; j++) {
		if ((i != j) && this.tsp[i][j] < min) {
			min = this.tsp[i][j];
			this.route[counter] = j + 1;
		}
	}
	sum += min;
}

function solve() {
	var path = new Path();
	path.findMinRoute();
	return path.route;
}
