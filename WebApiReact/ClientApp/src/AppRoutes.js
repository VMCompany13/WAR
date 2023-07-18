import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Users } from "./components/Users";
import { Dishes } from "./components/Dishes";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/users',
    element: <Users />
  },
  {
    path: '/dishes',
    element: <Dishes />
  }
];

export default AppRoutes;
