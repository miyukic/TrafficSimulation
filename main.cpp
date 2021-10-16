#include <iostream>
#include <memory>
#include <string>
#include <vector>
#incluce "traffic"

namespace myk {

class TrafficMember {
};


//車
class Car : public TrafficMember {
};


class RoadParts {
  public:
      std::string nama{"no name"};
      uint32_t id{0};
};


//道路
class RoadBase : public RoadParts {

  public:
    double length   = 0.0;
    double width    = 0.0;

    RoadBase(double length, double width) : length{length}, width{width} {
    }

};


//信号機
class TrafficLight : public RoadParts {

  public:
    enum class Status {
        red,
        yellow,
        blue,
        special,
        length
    };

    Status status{Status::red};

    TrafficLight(Status status) : status{status} {
    }

};

//道路の通過点
class RoadNode : public RoadParts {

  public:
    double xPoint, yPoint = 0;
    std::unique_ptr<TrafficLight*> trafficLight{};

    std::vector<RoadBase> connectedRoadvec{};

    RoadNode() {};
    RoadNode(double x, double y) : xPoint{x}, yPoint{y} { }

    RoadBase& connect(RoadBase& road) {
        connectedRoadvec.push_back(road);
        return road;
    }

};

//道路の交差点
class InterSection : public RoadNode {
  public:
};


} // namespace myk end.


using namespace myk;

int main() {
    std::unique_ptr<RoadNode> nodeN = std::make_unique<RoadNode>(RoadNode());
    std::unique_ptr<RoadNode> nodeM = std::make_unique<RoadNode>(RoadNode());
    RoadBase &road = nodeN->connect(RoadBase(30, 5));
    return 0;
}
