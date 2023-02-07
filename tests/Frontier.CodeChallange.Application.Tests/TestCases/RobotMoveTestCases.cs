using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Tests.Entities;
using Frontier.CodeChallange.Domain.Entities;
using Frontier.CodeChallange.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Tests.TestCases
{
    public class RobotMoveTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetMoveNotOnTableTestCase();
            yield return GetMoveFrom00EastTestCase();
            yield return GetMoveFrom00SouthTestCase();
            yield return GetMoveFrom00WestTestCase();
            yield return GetMoveFrom00NorthTestCase();
            yield return GetMoveFrom05EastTestCase();
            yield return GetMoveFrom05SouthTestCase();
            yield return GetMoveFrom05WestTestCase();
            yield return GetMoveFrom05NorthTestCase();
            yield return GetMoveFrom55EastTestCase();
            yield return GetMoveFrom55SouthTestCase();
            yield return GetMoveFrom55WestTestCase();
            yield return GetMoveFrom55NorthTestCase();
            yield return GetMoveFrom50EastTestCase();
            yield return GetMoveFrom50SouthTestCase();
            yield return GetMoveFrom50WestTestCase();
            yield return GetMoveFrom50NorthTestCase();
        }

        private object[] GetMoveFrom50NorthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 0,
                        Direction = FacingDirection.NORTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 5,
                        Y = 1,
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on bottom right corner facing north"
                }
            };
        }

        private object[] GetMoveFrom50WestTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 0,
                        Direction = FacingDirection.WEST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 4,
                        Y = 0,
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work bottom right corner facing west"
                }
            };
        }

        private object[] GetMoveFrom50SouthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 0,
                        Direction = FacingDirection.SOUTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 5,
                        Y = -1,
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked bottom right corner facing west"
                }
            };
        }

        private object[] GetMoveFrom50EastTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 0,
                        Direction = FacingDirection.EAST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 6,
                        Y = 0,
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked bottom right corner facing east"
                }
            };
        }

        private object[] GetMoveFrom55NorthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 5,
                        Direction = FacingDirection.NORTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 5,
                        Y = 6,
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on top right corner facing north"
                }
            };
        }

        private object[] GetMoveFrom55WestTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 5,
                        Direction = FacingDirection.WEST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 4,
                        Y = 5,
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on top right corner facing west"
                }
            };
        }

        private object[] GetMoveFrom55SouthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 5,
                        Direction = FacingDirection.SOUTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 5,
                        Y = 4,
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on top right corner facing south"
                }
            };
        }

        private object[] GetMoveFrom55EastTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 5,
                        Y = 5,
                        Direction = FacingDirection.EAST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 6,
                        Y = 5,
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on top right corner facing east"
                }
            };
        }

        private object[] GetMoveFrom05NorthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 5,
                        Direction = FacingDirection.NORTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 6,
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on top left corner facing north"
                }
            };
        }

        private object[] GetMoveFrom05WestTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 5,
                        Direction = FacingDirection.WEST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = -1,
                        Y = 5,
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on top left corner facing west"
                }
            };
        }

        private object[] GetMoveFrom05SouthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 5,
                        Direction = FacingDirection.SOUTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 4,
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on top left corner facing south"
                }
            };
        }

        private object[] GetMoveFrom05EastTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 5,
                        Direction = FacingDirection.EAST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 1,
                        Y = 5,
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on top left corner facing east"
                }
            };
        }

        private object[] GetMoveFrom00NorthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.NORTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 1,
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on bottom left corner facing north"
                }
            };
        }

        private object[] GetMoveFrom00WestTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.WEST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = -1,
                        Y = 0,
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on bottom left corner facing west"
                }
            };
        }

        private object[] GetMoveFrom00SouthTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.SOUTH
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = -1,
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Move should be blocked on bottom left corner facing south"
                }
            };
        }

        private object[] GetMoveFrom00EastTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.EAST
                    },
                    IsPlacedOnTable = true,
                    TableWidth = 6,
                    ExpectedNextLocation = new Position
                    {
                        X = 1,
                        Y = 0,
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move should work on bottom left corner facing east"
                }
            };
        }

        private object[] GetMoveNotOnTableTestCase()
        {
            return new object[]
            {
                new RobotMoveTestCase
                {
                    CurrentLocation = null,
                    IsPlacedOnTable = false,
                    TableWidth = 5,
                    ExpectedNextLocation = null,
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore
                    },
                    TestName = "Move should be ignored if not on table"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
