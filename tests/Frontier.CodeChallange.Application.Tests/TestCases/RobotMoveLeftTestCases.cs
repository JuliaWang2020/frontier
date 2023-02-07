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
    public class RobotMoveLeftTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetMoveLeftFrom00EastTestCase();
            yield return GetMoveLeftFrom00SouthTestCase();
            yield return GetMoveLeftFrom00WestTestCase();
            yield return GetMoveLeftFrom00NorthTestCase();
            yield return GetMoveLeftNotOnTableTestCase();
        }

        private object[] GetMoveLeftNotOnTableTestCase()
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
                    TestName = "Move left should be ignored if not on table"
                }
            };
        }

        private object[] GetMoveLeftFrom00NorthTestCase()
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
                    TableWidth = 5,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move left should work when facing north"
                }
            };
        }

        private object[] GetMoveLeftFrom00WestTestCase()
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
                    TableWidth = 5,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move left should work when facing west"
                }
            };
        }

        private object[] GetMoveLeftFrom00SouthTestCase()
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
                    TableWidth = 5,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move left should work when facing south"
                }
            };
        }

        private object[] GetMoveLeftFrom00EastTestCase()
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
                    TableWidth = 5,
                    ExpectedNextLocation = new Position
                    {
                        X = 0,
                        Y = 0,
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move left should work when facing east"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
