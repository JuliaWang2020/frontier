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
    public class RobotMoveRightTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetMoveRightFrom00EastTestCase();
            yield return GetMoveRightFrom00SouthTestCase();
            yield return GetMoveRightFrom00WestTestCase();
            yield return GetMoveRightFrom00NorthTestCase();
            yield return GetMoveRightNotOnTableTestCase();
        }

        private object[] GetMoveRightNotOnTableTestCase()
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
                    TestName = "Move right should be ignored if not on table"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private object[] GetMoveRightFrom00EastTestCase()
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
                        Direction = FacingDirection.SOUTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move right should work when facing east"
                }
            };
        }

        private object[] GetMoveRightFrom00NorthTestCase()
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
                        Direction = FacingDirection.EAST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move right should work when facing north"
                }
            };
        }

        private object[] GetMoveRightFrom00SouthTestCase()
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
                        Direction = FacingDirection.WEST
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move right should work when facing south"
                }
            };
        }

        private object[] GetMoveRightFrom00WestTestCase()
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
                        Direction = FacingDirection.NORTH
                    },
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Move right should work when facing west"
                }
            };
        }
    }
}
